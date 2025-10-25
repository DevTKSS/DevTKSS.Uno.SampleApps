#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Builds DocFX documentation with clean API regeneration.

.DESCRIPTION
    1. Cleans obsolete API documentation files
    2. Regenerates metadata from current source code
    3. Builds the documentation site

.EXAMPLE
    .\Build-Docs.ps1
#>

[CmdletBinding()]
param(
    [Parameter()]
    [ValidateSet('Quiet', 'Info', 'Warning', 'Error', 'Verbose')]
    [string]$LogLevel = 'Warning'
)

Set-Location $PSScriptRoot

# Step 1: Clean obsolete API docs
Write-Host "`n==> Cleaning obsolete API documentation..." -ForegroundColor Cyan
& .\Clean-ApiDocs.ps1

# Step 2: Run DocFX (metadata + build + pdf in one command)
Write-Host "`n==> Running DocFX (metadata, build, pdf)..." -ForegroundColor Cyan
docfx docfx.json --logLevel $LogLevel
if ($LASTEXITCODE -ne 0) {
    Write-Error "DocFX build failed"
    exit $LASTEXITCODE
}

Write-Host "`n✓ Documentation built successfully!" -ForegroundColor Green
Write-Host "Output: $PSScriptRoot\_site" -ForegroundColor Gray
