#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Cleans obsolete API documentation files before regenerating with DocFX.

.DESCRIPTION
    Removes all generated YAML files from the api/ directory and the _site/
    output folder to ensure only current types are documented and built.
    Preserves any manually-created markdown files like api/index.md.

.EXAMPLE
    .\Clean-ApiDocs.ps1
#>

[CmdletBinding()]
param()

$apiPath = Join-Path $PSScriptRoot "api"
$sitePath = Join-Path $PSScriptRoot "_site"

# Clean API folder
if (Test-Path $apiPath) {
    Write-Host "Cleaning API documentation folder: $apiPath" -ForegroundColor Cyan
    
    # Remove all .yml files (generated API docs)
    Get-ChildItem -Path $apiPath -Filter "*.yml" -File | Remove-Item -Force -Verbose
    
    Write-Host "✓ Cleaned obsolete API documentation files" -ForegroundColor Green
} else {
    Write-Host "API folder does not exist yet: $apiPath" -ForegroundColor Yellow
}

# Clean _site folder
if (Test-Path $sitePath) {
    Write-Host "Cleaning output site folder: $sitePath" -ForegroundColor Cyan
    Remove-Item -Path $sitePath -Recurse -Force -Verbose
    Write-Host "✓ Cleaned output site folder" -ForegroundColor Green
} else {
    Write-Host "Output site folder does not exist yet: $sitePath" -ForegroundColor Yellow
}
