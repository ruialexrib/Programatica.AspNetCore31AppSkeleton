#!/bin/bash

cd Programatica.AspNetCore31AppSkeleton

# stop and remove all services
docker-compose down

# remove old files
sudo rm -r Programatica.AspNetCore31AppSkeleton/

# clean unused artifacts
docker system prune -a -f

# clone source code repo
git clone https://github.com/ruialexrib/Programatica.AspNetCore31AppSkeleton.git

cd Programatica.AspNetCore31AppSkeleton/

# build image and push to docherhub
docker build -t aspnetcore31appskeleton .
docker tag aspnetcore31appskeleton kryptoncontainer/aspnetcore31appskeleton:latest
docker push kryptoncontainer/aspnetcore31appskeleton

# remove unused artifacts
docker system prune -a -f

# start
docker-compose up -d



