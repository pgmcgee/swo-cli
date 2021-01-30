# Delete build directory to clean
Remove-Item -Path .\build -Recurse -Force -ErrorAction Ignore

# Create build directory if it doesn't exist
New-Item -ItemType Directory -Path .\build -Force

# Copy all plugins into build
Copy-Item -Path .\plugins -Destination .\build -Recurse -Force

# Copy in the built exe
Copy-Item -Path .\bin\Release\net5.0\win10-x64\* -Destination .\build -Force

# Create zip archive
Remove-Item -Path .\build.zip -Force -ErrorAction Ignore
Compress-Archive -Path .\build -DestinationPath .\build.zip 