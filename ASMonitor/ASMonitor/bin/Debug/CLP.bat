@ECHO OFF

SET CLPCWD=%CD%
SET CLPOriginalPath=%PATH%
SET PATH=%PATH%;%CLPCWD%\CLPTools\

CLS
ECHO [CMD Line Interface for Plurk]
IF "%1"=="Login" (	
	ECHO - Force login.
	CALL :CLPLogin %2 %3
	SHIFT
	SHIFT
	SHIFT
)

IF "%CLPError%"=="1" (
	ECHO - ERROR: %CLPErrorMSG%
	CALL :CLPCleanUp
	EXIT /B 1
)

IF "%CLPIsLoggedIn%"=="0" (
	CALL :CLPCheckSession
)

FOR /F "tokens=2 delims= " %%A IN ('TYPE CLPUID.txt') DO @(
	SET CLPUID=%%A
)

ECHO - - CLPUID: %CLPUID%

IF "%CLPError%"=="1" (
	ECHO - ERROR: %CLPErrorMSG%
	CALL :CLPCleanUp
	EXIT /B 1
)

:CLPCommandLine
SET CLPCommand=%1
SHIFT

IF "%CLPCommand%"=="ReplyID" (
	SET CLPReplyID=%1
	SET CLPIsReplyIDSet=1
	SHIFT
	ECHO "plurk_id": %CLPReplyID% > CLPReplyID.txt
	GOTO :CLPCommandLine
)

IF "%CLPCommand%"=="Verb" (
	SET CLPVerb=%1
	SHIFT
	GOTO :CLPCommandLine
)


IF "%CLPVerb%."=="." (
	SET CLPVerb=:
)

IF "%CLPIsReplyIDSet%."=="." (
	CALL :CLPDefaultReplyID
)

FOR /F "tokens=*" %%A IN ('PlurkDateTime.exe') DO @(
	SET CLPDateTime=%%A
)

ECHO - Building CLPPlurk
ECHO - - CLPVerb: %CLPVerb%
IF "%CLPCommand%"=="Reply" (
	ECHO - - CLPReplyID: %CLPReplyID%
)
ECHO - - CLPCommand: %CLPCommand%

SET CLPContent=%1
IF "%1."=="." GOTO :CLPBuildContentDone
:CLPBuildContent
SHIFT
IF "%1."=="." GOTO :CLPBuildContentDone
SET CLPContent=%CLPContent% %1
GOTO :CLPBuildContent
:CLPBuildContentDone

ECHO - - CLPContent: %CLPContent%
CALL PlurkChars.exe %CLPContent%
IF "%ERRORLEVEL%"=="1" (
	ECHO - ERROR: CLPContent exceeds 140 characters.
	CALL :CLPCleanUp
	EXIT /B 1
)
IF "%CLPCommand%."=="." (
	ECHO - ERROR: CLPCommand is NULL
	CALL :CLPCleanUp
	EXIT /B 1
)

CALL :CLP%CLPCommand%

IF "%CLPError%"=="1" (
	ECHO - ERROR: %CLPErrorMSG%
	CALL :CLPCleanUp
	EXIT /B 1
)

GOTO :CLPCleanUp

:CLPLogin
SET CLPNickname=%1
SET CLPPassword=%2

IF EXIST "CLPCookies.txt" (
	DEL CLPCookies.txt
)

IF EXIST "CLPUID.txt" (
	DEL CLPUID.txt
)

IF EXIST "CLPLogin.txt" (
	DEL CLPLogin.txt
)

curl -s -b CLPCookies.txt -c CLPCookies.txt -d "nick_name=%CLPNickname%&password=%CLPPassword%" http://www.plurk.com/Users/login >> CLPLogin.txt
grep -oP -m 1 "a href=""/%CLPNickName%""" CLPLogin.txt >> NUL
IF "%ERRORLEVEL%"=="0" (
	ECHO - - Login successful.
	SET CLPIsLoggedIn=1
	ECHO Nickname %CLPNickName% > CLPSession.txt
	ECHO Password %CLPPassword% >> CLPSession.txt
) ELSE (
	SET CLPIsLoggedIn=0
	SET CLPError=1
	SET CLPErrorMSG=Invalid Username/Password :: Check case sensitivity.
	GOTO :EOF
)

ECHO - Getting CLPUID
curl -s -b CLPCookies.txt -c CLPCookies.txt http://www.plurk.com/%CLPNickname% | grep -oP -m 1 \""user_id\"":.\d* >> CLPUID.txt
IF "%ERRORLEVEL%"=="0" (
	ECHO - - CLPUID Obtained.
) ELSE (
	SET CLPError=1
	SET CLPErrorMSG=Failure while obtaining CLPUID
	GOTO :EOF
)

GOTO :EOF

:CLPCheckSession
IF NOT EXIST "CLPCookies.txt" (
	SET CLPIsLoggedIn=0
	SET CLPError=1
	SET CLPErrorMSG=Login not specified and existing session not found.
	GOTO :EOF
)

IF NOT EXIST "CLPSession.txt" (
	SET CLPIsLoggedIn=0
	SET CLPError=1
	SET CLPErrorMSG=Login not specified and existing session not found.
	GOTO :EOF
)

FOR /F "tokens=2 delims= " %%A IN ('grep -P -m 1 Nickname CLPSession.txt') DO @(
	SET CLPNickname=%%A
)
FOR /F "tokens=2 delims= " %%A IN ('grep -P -m 1 Password CLPSession.txt') DO @(
	SET CLPPassword=%%A
)

curl -s -b CLPCookies.txt -c CLPCookies.txt http://www.plurk.com >> CLPCheckSession.txt
grep -oP -m 1 "a href=""/%CLPNickName%""" CLPCheckSession.txt >> NUL
IF "%ERRORLEVEL%"=="0" (
	SET CLPIsLoggedIn=1
	ECHO - Session is still valid.
) ELSE (
	SET CLPIsLoggedIn=0
	ECHO - Session is no longer valid.  Attempting login.
	CALL :CLPLogin %CLPNickName% %CLPPassword%
)

DEL CLPCheckSession.txt
GOTO :EOF

:CLPDefaultReplyID
FOR /F "tokens=2 delims= " %%A IN ('TYPE CLPReplyID.txt') DO @(
	SET CLPReplyID=%%A
)

GOTO :EOF

:CLPPost
IF EXIST "CLPReplyID.txt" (
	DEL CLPReplyID.txt
)
IF "%CLPContent%."=="." (
	SET CLPError=1
	SET CLPErrorMSG=No content to post
	GOTO :EOF
)

ECHO - CLPPlurk Post.
curl -s -b CLPCookies.txt -c CLPCookies.txt -d "qualifier=%CLPVerb%&lang=en&no_comments=0&uid=%CLPUID%&content=%CLPContent%" http://www.plurk.com/TimeLine/addPlurk | grep -oP -m 1 \""plurk_id\"":.\d* >> CLPReplyID.txt

IF "%ERRORLEVEL%"=="0" (
	ECHO - - CLPPlurk Post Success.
) ELSE (
	SET CLPError=1
	SET CLPErrorMSG=CLP Post Failure
	ECHO "plurk_id": %CLPReplyID% > CLPReplyID.txt
)
GOTO :EOF

:CLPReply
IF "%CLPReplyID%."=="." (
	SET CLPError=1
	SET CLPErrorMSG=Reply specified but no ReplyID
	GOTO :EOF
)

ECHO - CLPPlurk Reply.
curl -s -b CLPCookies.txt -c CLPCookies.txt -d "plurk_id=%CLPReplyID%&qualifier=%CLPVerb%&lang=en&content=%CLPContent%&p_uid=%CLPUID%&uid=%CLPUID%&posted=%CLPDateTime%" http://www.plurk.com/Responses/add | grep -oP -m 1 \""plurk_id\"":.\d* >> NUL
IF "%ERRORLEVEL%"=="0" (
	ECHO - - CLPPlurk Reply Success.
) ELSE (
	SET CLPError=1
	SET CLPErrorMSG=CLP Reply Failure
)

GOTO :EOF

:CLPCleanUp
SET CLPDebug=
SET CLPIsReplyIDSet=
SET CLPIsLoggedIn=
SET CLPNickname=
SET CLPPassword=
SET CLPError=
SET CLPErrorMSG=
SET CLPCommand=
SET CLPContent=
SET CLPDateTime=
SET CLPVerb=
SET CLPUID=
SET PATH=%CLPOriginalPath%
SET CLPCWD=
SET CLPOriginalPath=
GOTO :EOF

:EOF
