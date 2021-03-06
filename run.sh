echo "-- Iniciando a execucao";

echo "-- Buildando aplicação e subindo containeres";

docker-compose up --build -d

echo "-- Build finalizada.";

read -p "Pressione qualquer tecla para finalizar" x