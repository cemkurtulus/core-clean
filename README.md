# core-clean

.Net 8.0 Core Clean Architecture

Autofac

Entity Framework Core

FluentValidation

PostgresSQL

docker-compose up --build

```
create table public.customer
(
    id    uuid    not null,
    name  varchar,
    email varchar not null
);

alter table public.customer
    owner to postgres;
```