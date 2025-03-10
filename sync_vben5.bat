@echo off
chcp 65001 > nul

:: ============== 配置参数 ==============
set "REMOTE_NAME=vben5"          :: 远程仓库别名
set "UPSTREAM_URL=https://github.com/vbenjs/vue-vben-admin.git"  :: 仓库URL
set "BRANCH=main"               :: 分支名称
set "SUBDIR=apps/vben5"         :: 本地存放子仓库的目录
:: =====================================

:: 配置远程仓库（静默模式）
git remote add %REMOTE_NAME% %UPSTREAM_URL% 2> nul

:: 智能选择初始化或同步
if exist "%SUBDIR%" (
    git -c core.quotepath=false subtree pull --prefix="%SUBDIR%" %REMOTE_NAME% %BRANCH% --squash
) else (
    git -c core.quotepath=false subtree add --prefix="%SUBDIR%" %REMOTE_NAME% %BRANCH% --squash
)

:: 统一结果处理
if %errorlevel% equ 0 (
    echo 同步成功！
) else (
    echo 同步失败！代码：%errorlevel%
    pause
)
exit /b