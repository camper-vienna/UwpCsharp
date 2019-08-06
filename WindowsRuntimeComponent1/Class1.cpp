#include "pch.h"
#include "Class1.h"

using namespace WindowsRuntimeComponent1;
using namespace Platform;

Class1::Class1()
{
	int* foo = (int *)42;
	m_test = *foo + 23;
}
