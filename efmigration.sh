#!/bin/bash

echo "Run Migration"

sh "dotnet ef migrations add InitalCreate"
sh "dotnet ef migrations database update"