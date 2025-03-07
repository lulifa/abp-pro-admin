@echo off
chcp 65001 > nul
git remote add vben5 https://github.com/vbenjs/vue-vben-admin.git 2> nul
git log -1 -- apps/vben5 2> nul || git subtree add --prefix=apps/vben5 vben5 main --squash
git -c core.quotepath=false subtree pull --prefix=apps/vben5 vben5 main --squash
if %errorlevel% equ 0 (echo 同步成功！) else (echo 同步失败！代码：%errorlevel% && pause )
exit