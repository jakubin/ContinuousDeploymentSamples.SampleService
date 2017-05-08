param(
  [hashtable] $appSettings
)

$path = 'AcceptanceTests.dll.config'
$config = [xml](Get-Content $path)

foreach ($key in $appSettings.Keys) {
    $node = $config.configuration.appSettings.add | where {$_.Key -eq $key}
	$node.value = $appSettings.Item($key)
}

$config.Save($path)