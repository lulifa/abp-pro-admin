@echo off
chcp 65001 > nul
set SUBDIR=apps/vben5

git log -1 --format= -- "%SUBDIR%" 2> nul && goto SYNC
git remote add vben5 https://github.com/vbenjs/vue-vben-admin.git 2> nul
git subtree add --prefix="%SUBDIR%" vben5 main --squash || pause && exit

:SYNC
git -c core.quotepath=false subtree pull --prefix="%SUBDIR%" vben5 main --squash
echo 操作完成 & pause