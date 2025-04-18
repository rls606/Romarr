@echo off
setlocal

set PROJECT_NAME=romarr-api

echo 🔄 Nettoyage de l'environnement Docker...
docker-compose down

echo 🗑️ Suppression des images existantes...
for /f "tokens=*" %%i in ('docker images --filter^=reference^="*%PROJECT_NAME%*" -q') do (
    docker rmi %%i
)

echo 🧹 Nettoyage des ressources Docker non utilisées...
docker system prune -f

echo 🏗️ Reconstruction et démarrage du conteneur...
docker-compose up

echo ✅ Environnement Docker redémarré et prêt pour le débogage!