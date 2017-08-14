# Robotic-Fuel-Tank-Buffer
Industrial robotic arm that sends fuel tanks to buffing stations in an assembly line manner.

The purpose of this project is to use an industrial size robotic arm to pick up fuel tanks and move them through a system in an assembly
line fashion to polish these fuel tanks.

The idea is that a person will put a fuel tank in the entry window and press the start button. Then, once the fuel tank has been polished,
the person will remove the fuel tank. That is the only thing the human will have to do in this project.

The robotic arm will move the fuel tanks between the entry window, buffer station 1, buffer station 2, and the exit window. This will
not be a linear process, this will be a multi layered approach. Once one station is done, it will check the next station. If the next
station is done and available, the computer will tell the PIC to tell the robotic arm to move the fuel tank as needed. Ideally there will
be one fuel tank in each buffer as often as possible.

There are many sensors through the design. These sensors will send signals to the PIC about the physical processes of the assembly line,
which will then control what the VB.net software tells the PIC to do in the physical process.
