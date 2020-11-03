#!/bin/bash

# remove old files
sudo rm -r Programatica.AspNetCore31AppSkeleton/

# clone source code repo
git clone https://github.com/ruialexrib/Programatica.AspNetCore31AppSkeleton.git

cd Programatica.AspNetCore31AppSkeleton/

# build image and push to docherhub
docker build -t aspnetcore31appskeleton .
docker tag aspnetcore31appskeleton kryptoncontainer/aspnetcore31appskeleton:latest
docker push kryptoncontainer/aspnetcore31appskeleton

# remove unused artifacts
docker system prune -a

cd Programatica.AspNetCore31AppSkeleton/

# update images
docker-compose pull

# restart containers
docker-compose restart



