@echo off
	goto main

-- Info	--
WifiShare helper script 

(c) Elias Bachaalany <lallousz-x86@yahoo.com>

-- History --

06/07/2014 - eliasb   - Initial version
--

:main

    if "%1"=="start" goto start
    if "%1"=="stop"  goto stop
    if "%1"=="check" goto check
	if "%1"=="show"	 goto show
    
    goto usage

:start
    shift
    
    if "%1"=="" goto usage
    if "%2"=="" goto usage

    rem Configure the hosted network parameters
    netsh wlan set hostednetwork mode=allow ssid="%1" key="%2"

    rem Start the hosted network
    netsh wlan start hostednetwork

    rem Exit with failure
    if not errorlevel 0 exit 1981

    goto end

:check
    netsh wlan show drivers | find "Hosted network supported" | find  "Yes" > nul
    if not errorlevel 0 exit 1981
    goto end

:stop
    shift
    netsh wlan stop hostednetwork
    goto end

:show
	netsh wlan show hostednetwork
	goto end

:usage
    echo Usage: %0 start ssid_name key_value
    echo        %0 stop
	echo        %0 check (returns error code only)
	echo        %0 show
    
    goto end

:end