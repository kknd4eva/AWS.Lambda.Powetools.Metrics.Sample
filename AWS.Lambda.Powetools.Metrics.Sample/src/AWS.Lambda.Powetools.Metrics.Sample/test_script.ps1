if (-not $args) {
  Write-Output "Usage: .\test_script.ps1 <api-id>"
  exit 1
}

$api_id = $args[0]

for ($i = 1; $i -le 1000; $i++) {
  $value = Get-Random -Minimum 1 -Maximum 300
  Invoke-RestMethod -Uri "https://$api_id.execute-api.ap-southeast-2.amazonaws.com/metrics/embedded/production/$value" -Method Post
  Start-Sleep -Seconds 1
}
