package main
import "C"

/*
代码运行方式：
在 code 目录下，直接使用 go build 或者 go install 命令，即可生成可执行的文件
*/

//#include "foo.h"
import "C"

func main() {
	println(C.fun1());
	println(C.fun2(2))
}