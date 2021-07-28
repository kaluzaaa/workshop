FROM ubuntu
RUN apt update -y &&  apt install -y tree
WORKDIR /src
COPY . .
CMD ls -la && tree