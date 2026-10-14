@echo off
cd /d "%~dp0"
docker compose up --build -d
if errorlevel 1 (
  echo Build failed. Check Docker Desktop and logs.
  pause
  exit /b 1
)
echo Website: http://localhost:5181
echo Health API: http://localhost:8081/api/health
pause
