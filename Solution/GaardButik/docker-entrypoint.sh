#!/bin/sh
set -e

# Wait for the PostgreSQL server to start
until pg_isready -h localhost -p 5432
do
  echo "Waiting for PostgreSQL server to start..."
  sleep 1
done

# Execute the specified command or fall back to the default command
exec "$@"