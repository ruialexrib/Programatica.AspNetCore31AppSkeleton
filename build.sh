#!/bin/bash

sudo rm -r Programatica.AspNetCore31AppSkeleton/

git clone https://github.com/ruialexrib/Programatica.AspNetCore31AppSkeleton.git

cd Programatica.AspNetCore31AppSkeleton/

docker build -t aspnetcore31appskeleton .
docker tag aspnetcore31appskeleton kryptoncontainer/aspnetcore31appskeleton:latest
docker push kryptoncontainer/aspnetcore31appskeleton

docker system prune -a