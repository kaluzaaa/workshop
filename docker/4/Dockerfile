FROM ubuntu
ARG env=dev
ENV env=${env}
ARG VCS_REF
ENV GIT_SHA $VCS_REF
RUN apt update -y
RUN apt install -y iproute2
ENV workshop_day=1
CMD echo "Hello world! Day: ${workshop_day}, Env=${env}, GIT: ${GIT_SHA}"