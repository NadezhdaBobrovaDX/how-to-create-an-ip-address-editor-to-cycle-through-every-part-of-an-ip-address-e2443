# How to create an IP address editor to cycle through every part of an IP address


<p>If you need an IP address editor with a spin edit capable to change values in cycle from 0 to 255 for every single part of an IP address this example explains how to obtain it. This editor corresponds to a descendant of the TimeEdit control and its behavior is based on storing an IP address as a value of type DateTime. The IP address is simply transformed to a value of type Int64 and assigned to the Ticks property of the DateTime value. The ability to cycle through IP address parts is achieved by assigning a mask of type "d.h.m.s" (Day, Hour, Minute, Second) and changing the low and high cycle bounds in theTimeEdit descendant to 0 and 255 respectively.</p>

<br/>


