$ErrorActionPreference = "Stop"

# ��ȡ��ǰ�ű����ڵ�Ŀ¼
$currentDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# ��ȡ csproj �ļ�
$csprojFile = Join-Path -Path $currentDir -ChildPath "WeChatMultiOpen.csproj"
$csproj = [xml](Get-Content -Path $csprojFile)

Write-Host "${csproj.Version}"

# ��ȡ���а��� Version ���Ե� PropertyGroup Ԫ��
$propertyGroups = $csproj.Project.PropertyGroup | Where-Object { $_.Version }

# ����汾��
foreach ($propertyGroup in $propertyGroups) {
    $version = $propertyGroup.Version
    $ssemblyVersion = $propertyGroup.AssemblyVersion
    $FileVersion = $propertyGroup.FileVersion

    Write-Host "�汾: $version"
    Write-Host "����汾: $ssemblyVersion"
    Write-Host "�ļ��汾: $FileVersion"
}

# ��ȡ��ǰ�汾�ŵĸ�������
$major = [int]$propertyGroups.MajorVersion
$minor = [int]$propertyGroups.MinorVersion
$patch = [int]$propertyGroups.PatchVersion
$build = [int]$propertyGroups.BuildVersion

Write-Host "��ǰ�汾��$major.$minor.$patch.$build"

# ���� Build �汾�Ų�������9999�����
if ($build -lt 9999) {
    $build++
} else {
    $build = 0
    if ($patch -lt 999) {
        $patch++
    } else {
        $patch = 0
        if ($minor -lt 99) {
            $minor++
        } else {
            $minor = 0
            $major++
        }
    }
}

Write-Host "�ϲ��汾: $major.$minor.$patch.$build"

# ���°汾��
$newVersion = "$major.$minor.$patch.$build"

foreach ($propertyGroup in $propertyGroups) {
    $propertyGroup.MajorVersion = $major.ToString()
    $propertyGroup.MinorVersion = $minor.ToString()
    $propertyGroup.PatchVersion = $patch.ToString()
    $propertyGroup.BuildVersion = $build.ToString()
    $propertyGroup.Version = $newVersion
    $propertyGroup.AssemblyVersion = $newVersion
    $propertyGroup.FileVersion = $newVersion
}

# �����޸ĺ�� csproj �ļ�
$csproj.Save($csprojFile)

# ������º�İ汾��
Write-Host "�汾���Ѹ���Ϊ: $newVersion"
