@echo off
chcp 65001 > nul

:: ============== 配置区 ==============
set SUBDIR=apps/vben5
set UPSTREAM_URL=https://github.com/vbenjs/vue-vben-admin.git
set BRANCH=main
set REMOTE_NAME=vben5
:: ===================================

:: 静默模式初始化检测
git log -1 --format= -- "%SUBDIR%" 2> nul
if %errorlevel% neq 0 (
    echo [Init] 正在初始化子仓库 %SUBDIR%...
    git remote add %REMOTE_NAME% %UPSTREAM_URL% 2> nul
    git subtree add --prefix="%SUBDIR%" %REMOTE_NAME% %BRANCH% --squash
    if errorlevel 1 (
        echo [Error] 初始化失败！代码：%errorlevel%
        echo [Solution] 请手动删除 %SUBDIR% 文件夹后重试
        pause
        exit /b
    )
    echo [Success] 初始化完成
)

:: 执行同步
git -c core.quotepath=false subtree pull --prefix="%SUBDIR%" %REMOTE_NAME% %BRANCH% --squash
if %errorlevel% equ 0 (
    echo [Success] 同步完成
) else (
    echo [Error] 同步失败！代码：%errorlevel%
    pause
)
exit /b