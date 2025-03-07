@echo off
chcp 65001 > nul
set SUBDIR=apps/vben5

:: 检测是否已初始化
git log -1 --format= -- "%SUBDIR%" 2> nul || (
    echo 首次初始化子仓库...
    git remote add vben5 https://github.com/vbenjs/vue-vben-admin.git 2> nul
    git subtree add --prefix="%SUBDIR%" vben5 main --squash || (
        echo 初始化失败! 错误码: %errorlevel%
        echo 请手动删除 %SUBDIR% 后重试
        pause
        exit
    )
)

:: 执行同步
git -c core.quotepath=false subtree pull --prefix="%SUBDIR%" vben5 main --squash
if %errorlevel% equ 0 (echo 同步成功！) else (echo 同步失败！代码：%errorlevel% && pause)
exit