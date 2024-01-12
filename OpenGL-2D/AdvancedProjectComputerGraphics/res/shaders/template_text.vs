#version 330 core

layout (location = 0) in vec4 aPos;
layout (location = 1) in vec3 aColor;
layout (location = 2) in vec2 aTexCoord;

out vec3 ourColor;
out vec2 TexCoord;

uniform mat4 u_Transformation;

void main(){
	gl_Position = u_Transformation * aPos;
	ourColor = aColor;
	TexCoord = aTexCoord;
};