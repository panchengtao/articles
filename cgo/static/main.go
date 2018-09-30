package main
import "C"

/*
静态库运行方式：
在当前目录下，使用 gcc -c foo.c 和 ar rcs -o libfoo.a foo.o 命令生成静态库文件。

好处是可以使用 goland 自带的调试运行机制，也可以使用 go build，go install，go run 命令生成可执行文件或直接执行，并且不需要添加动态库执行路径。
*/

//#cgo CFLAGS : -I./
//#cgo LDFLAGS: -L./ -lfoo
//#include "foo.h"
import "C"

func main() {
	println(C.fun1());
	println(C.fun2(2))
}
