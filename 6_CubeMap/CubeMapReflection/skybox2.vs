#version 430 core
layout (location = 0) in vec3 aPos;
//layout (location = 1) in vec2 aTexCoords;

out vec3 TexCoords;

uniform mat4 projection;
uniform mat4 view;

void main()
{
    //TexCoords = aTexCoords;
    //gl_Position = vec4(aPos.x, aPos.y, 0.0, 1.0); 

	TexCoords = aPos;

	vec4 pos = projection * view * vec4(aPos, 1.0);
	gl_Position = pos.xyww;
}  