@ECHO OFF
rem Pre build step. Currently does nothing
rem
rem The parameters to this batch file should be: 
rem    PreBuildStep.bat "$(ProjectDir) "
echo PreBuildStep.bat %1

goto done


:error
exit 1

:done
