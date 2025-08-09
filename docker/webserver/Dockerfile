FROM php:7.3-apache-buster

# Fix EOL Buster repositories
RUN set -eux; \
    sed -i 's|http://deb.debian.org/debian|http://archive.debian.org/debian|g' /etc/apt/sources.list || true; \
    sed -i 's|https://deb.debian.org/debian|http://archive.debian.org/debian|g' /etc/apt/sources.list || true; \
    sed -i 's|^deb .*security.debian.org.*|# removed: buster security moved/disabled|g' /etc/apt/sources.list || true; \
    apt-get -o Acquire::Check-Valid-Until=false update


# install packages
RUN apt-get update && \
  docker-php-ext-install mysqli && \
  apt-get upgrade -y && \
  apt-get install -y --no-install-recommends mariadb-client && \
  apt-get clean && \
  apt-get autoremove -y && \
  rm -rf /var/lib/apt/lists/* && \
  sed -e '/<Directory \/var\/www\/>/,/<\/Directory>/s/AllowOverride None/AllowOverride All/' -i /etc/apache2/apache2.conf && \
  echo "1" > /var/tmp/dockerwebserverversion

