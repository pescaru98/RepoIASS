@echo off

set database=pharmaonline
set dropAndCreate="DROP DATABASE IF EXISTS %database%; CREATE DATABASE %database%;"
set tables_query=tables.sql
set views_query=views.sql
set inserts_query=inserts.sql
set procedures = procedures.sql

mysql -u dev -e %dropAndCreate%

mysql -u dev %database% < %tables_query%
mysql -u dev %database% < %views_query%
mysql -u dev %database% < %inserts_query%
mysql -u dev %database% < %procedures%