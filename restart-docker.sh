#!/bin/bash

# Nom du projet pour l'image Docker
PROJECT_NAME="romarr-api"

echo "🔄 Nettoyage de l'environnement Docker..."
# Arrêter tous les conteneurs associés au docker-compose
docker-compose down

# Supprimer l'image Docker associée au projet
IMAGES=$(docker images --filter=reference="*${PROJECT_NAME}*" -q)
if [ -n "$IMAGES" ]; then
    echo "🗑️ Suppression des images existantes..."
    docker rmi $IMAGES
else
    echo "❕ Aucune image existante trouvée."
fi

# Nettoyer les ressources Docker non utilisées
echo "🧹 Nettoyage des ressources Docker non utilisées..."
docker system prune -f

# Reconstruire et démarrer le conteneur
echo "🏗️ Reconstruction et démarrage du conteneur..."
docker-compose up

echo "✅ Environnement Docker redémarré et prêt pour le débogage!"