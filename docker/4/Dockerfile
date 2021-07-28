FROM ubuntu
ARG env=dev
ENV env=${env}
RUN apt update -y
RUN apt install -y iproute2
ENV workshop_day=1
CMD echo "Hello world! Day: ${workshop_day}, Env=${env}"