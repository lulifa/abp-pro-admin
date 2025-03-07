@echo off
chcp 65001 > nul

set "REMOTE_NAME=vben5"
set "REMOTE_URL=https://github.com/vbenjs/vue-vben-admin.git"
set "BRANCH=main"
set "SUBDIR=apps/vben5"

git log -1 --format= -- "%SUBDIR%" 2> nul && goto SYNC
git remote add %REMOTE_NAME% %REMOTE_URL% 2> nul
git subtree add --prefix="%SUBDIR%" %REMOTE_NAME% %BRANCH% --squash || exit /b

:SYNC
git -c core.quotepath=false subtree pull --prefix="%SUBDIR%" %REMOTE_NAME% %BRANCH% --squash
echo 操作完成 & pause