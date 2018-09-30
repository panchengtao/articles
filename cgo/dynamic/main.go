package main
import "C"

/*
动态库运行方式：
1. 在当前目录下，使用 cc -fPIC -shared -o libfoo.so foo.c 命令生成动态库文件。

2. 将 libfoo.so 文件路径加入到 /etc/ld.so.conf 文件中，或将文件 cp 到 /usr/lib 或 /lib 中，最后运行 ldconfig。

好处是可以使用 goland 自带的调试运行机制，也可以使用 go build，go install，go run 命令生成可执行文件或直接执行。
*/

//#cgo CFLAGS : -I./
//#cgo LDFLAGS: -L./ -lfoo
//#include "foo.h"
import "C"

func main() {
	println(C.fun1());
	println(C.fun2(2))
}
