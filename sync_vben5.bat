@echo off
chcp 65001 > nul
git remote add vben5 https://github.com/vbenjs/vue-vben-admin.git 2> nul
git log -1 --format='' -- apps/vben5 2> nul
if %errorlevel% neq 0 (
    echo 正在初始化子仓库...
    git -c core.quotepath=false subtree add --prefix=apps/vben5 vben5 main --squash
    if %errorlevel% equ 0 (
        echo 子树初始化成功
    ) else (
        echo 初始化失败！代码：%errorlevel%
        echo 操作建议：删除 apps/vben5 目录后重试
        exit
    )
)
git -c core.quotepath=false subtree pull --prefix=apps/vben5 vben5 main --squash
if %errorlevel% equ 0 (echo 同步成功！) else (echo 同步失败！代码：%errorlevel% && pause )
exit