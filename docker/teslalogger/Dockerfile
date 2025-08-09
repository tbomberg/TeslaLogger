FROM mono:6.12.0.122

# timezone / date
RUN echo "Europe/Berlin" > /etc/timezone && dpkg-reconfigure -f noninteractive tzdata

# Fix EOL Buster repositories
RUN set -eux; \
    sed -i 's|http://deb.debian.org/debian|http://archive.debian.org/debian|g' /etc/apt/sources.list || true; \
    sed -i 's|https://deb.debian.org/debian|http://archive.debian.org/debian|g' /etc/apt/sources.list || true; \
    sed -i 's|^deb .*security.debian.org.*|# removed: buster security moved/disabled|g' /etc/apt/sources.list || true; \
    apt-get -o Acquire::Check-Valid-Until=false update

# install packages
RUN apt-get update && \
  apt-get upgrade -y && \
  apt-get install -y --no-install-recommends git && \
  apt-get install -y --no-install-recommends mariadb-client && \
  apt-get install -y optipng && \
  apt-get clean && \
  apt-get autoremove -y && \
  rm -rf /var/lib/apt/lists/* && \
  echo "export TERM=xterm" >> /root/.bashrc  && \
  echo "DOCKER" >> /tmp/teslalogger-DOCKER

WORKDIR /etc/teslalogger

CMD ["mono", "./TeslaLogger.exe"]
