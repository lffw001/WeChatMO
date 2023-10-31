
## 简介

&emsp;&emsp;WeChatMo是一个解除微信只能单开的限制的工具，你可能会疑问，为什么要写这么一个工具，有很多办法都可以实现微信多开，例如：选择微信图标后按住Ctrl键不松，快速双击图标或者按回车键，就可以实现多开；也可以使用脚本命令来实现微信多开，这里就不一一举例。

&emsp;&emsp;微信默认是不能多开的，当今基本上每个人都会有工作和私人两个微信，所以微信不能多开这个限制给我们带来了不小的麻烦，而以上的多开方法都会有一个缺陷：如果微信在运行的时候，如果想要多开必须要关闭微信才可以，而WeChatMo（以下简称MO）在运行一次之后，就可以自由的运行多开微信了。当然这样的工具也有很多，那为什么要自己造轮子呢？嗯，我是为了学习编程，我希望我在学习的同时，也能帮到其他人。

## 功能特点

* 操作简单：Mo会自动检测当前微信版本是否支持解除限制，如果不支持请在微信官方下载最新版本，或者在工具界面上的链接来下载。
* 一次解除：运行一次软件过后将永久有效，不需要重复运行。PS：如果微信更新后需要重新运行；
* 自由安装：文件可以放在任何一个地方运行都可以使用。
* 自动更新：在 v0.1.0.0 版本后，可在线更新特征码，无需要重复多次下载。

## 开发环境

* 运行框架：.NET 7 Desktop Runtime
* 操作系统：Windows 7 & Windows 10 & Windows 11
* 系统类型：64位操作系统
* 支持版本：PC微信电脑版 ≤ 3.5.8.9

## 发布地址

1. https://github.com/redsonw/WeChatMO/releases
2. https://www.redsonw.com/wechatmo.html

## 使用说明

&emsp;&emsp;由于是使用的.NET 7 框架开发，所以在运行此工具时，需要下载安装支持库Windows-Desktop-Runtime 7，下载地址：[ Runtime Desktop 7 ](https://www.redsonw.com/?golink=aHR0cHM6Ly9kb3dubG9hZC52aXN1YWxzdHVkaW8ubWljcm9zb2Z0LmNvbS9kb3dubG9hZC9wci9kZmZiMTkzOS1jZWYxLTRkYjMtYTU3OS01NDc1YTMwNjFjZGQvNTc4YjIwODczM2M5MTRjN2I3MzU3ZjZiYWE0ZWNmZDYvd2luZG93c2Rlc2t0b3AtcnVudGltZS03LjAuNS13aW4teDY0LmV4ZQ==)，下载后直接双击：WeChatMultiOpen，找到界面的按钮：解除限制，点击即可完成。

![图片[1]-解除微信多开工具-枫落墨痕](https://www.redsonw.com/wp-content/uploads/2023/06/WeChatMultiOpen.png)

### 目前缺陷

已经解决了频繁更新主程序的问题，目前使用的是远程更新特征字进行自动更新。但是依赖网络。

### 未来计划

- 免扫码登录

其实一直在计划着更新免扫码登录程序，之前有做过一个版本，但是由于电脑硬盘崩坏，丢失了我的所有数据，也包括了姐姐们，咳~ 所以现在免扫码是有计划做，但是由于工作原因进度会很缓慢，请见谅。

## 文件校验

名称: WeChatMo.exe
大小: 2150665 字节 (2100 KiB)
CRC32: 25472481
CRC64: 1E5C07883BBE20A8
SHA256: 507520bd1c2d400f9ac0381ff57bf1f9a4e56852b5ec68a1aee8fd8f1c95099b
SHA1: 86c5b7672a51dc0881c16b5f484f2cc7a8068f05
BLAKE2sp: 204b33f442614f99d843495d8f14cda6249c0da5a4017949d2415fdb507112df

## 更新日志

### 2023-10-31 v0.1.0.0

- 特征库升级至 v3.9.8.9；

### 2023-09-20 v0.1.0.0

- 程序版本跨度升级 v0.1.0.0 (意味着有功能更新)；
- 支持微信最新版本 3.9.7.25；
- 新增自动更新主程序；
- 新增在线更新特征值（在不更新主程序的情况下也能实现解除多开限制）；

### 2023-09-08 v0.0.2.4

- 更新版本号 0.0.2.4
- 支持微信最新版本 3.9.7.15。

### 2023-08-23 v0.0.2.3

- 更新版本号 0.0.2.3
- 支持微信最新版本 3.9.6.47。

### 2023-08-11 v0.0.2.2

- 日志构造函数使用C# 12 规则；
- 更新版本号 0.0.2.2
- 支持微信最新版本 3.9.6.43。

### 2023-07-23 v0.0.2.1

- 修正版本号错误导致无法登录；
- 版本号更新；
- 提高代码可读性；

### 2023-07-22 v0.0.1.116

- 支持PC微信电脑版 3.9.6.33 正式版。

### 2023-07-19 v0.0.1.115

- 修复无法使用的Bug。

### 2023-07-19 v0.0.1.114

- 支持PC微信电脑版 3.9.6.29 测试版。

### 2023-07-15 v0.0.1.113

- 支持PC微信电脑版 3.9.6.22 测试版。

### 2023-06-09 v0.0.1.112

1. 支持PC微信电脑版 3.9.5.91；
2. 删除自建版本号脚本。

### 2023-06-09 v0.0.0.111

1. 支持PC微信电脑版 3.9.5.81
2. 自动检查微信是否安装；
3. 自动识别系统已安装微信版本；

> 微信多开解除工具长期更新，如果遇到BUG请联系我或加QQ群：855181110

## 下载地址
| 网盘 | 链接地址 | 提取码 |
| :--: | --- | --- |
|123云盘|https://www.123pan.com/s/82ytVv-Vs6Bv.html|FLMH|
|百度网盘|https://pan.baidu.com/s/1b3LTfICH3kXnNuEwBrN8Tg|FLMH|
|蓝奏云|https://flmh.lanzouk.com/b0131ppde|ad7b|
|夸克网盘|https://pan.quark.cn/s/2c9489bc5369|无|
|阿里云盘|https://www.aliyundrive.com/s/odAZDmCPghP|6p7n|
|天翼云盘|https://cloud.189.cn/t/7zuamyiaUBbi|4xcr|
|Github|https://github.com/redsonw/WeChatMO|

## 免责申明

&emsp;&emsp;本工具仅作为学习使用，作者不对其适用性和可靠性做任何保证，也不承担任何与使用或误用本工具相关的责任。
