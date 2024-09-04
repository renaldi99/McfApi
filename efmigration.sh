#!/bin/bash

echo "Run Migration"

if [ -d ./McfApi ]; then
    cd ./McfApi
fi

pwd
ls -l -a
dotnet ef migrations add InitalCreate
dotnet ef database update