#version 430 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec3 norm;
layout(location = 2) in vec2 tex;

out VS_OUT
{
	vec3 FragPos;
	vec3 Normal;
	vec2 TexCoords;
	vec4 FragPosLightSpace;
} vs_out;

uniform mat4 lightSpaceMatrix;
uniform mat4 model;
uniform mat4 projection;
uniform mat4 view;

void main()
{
	vs_out.FragPos = vec3(model * vec4(pos, 1.0f));
	vs_out.Normal = normalize(transpose(inverse(mat3(model))) * norm);
	vs_out.TexCoords = tex;
	vs_out.FragPosLightSpace = lightSpaceMatrix * model * vec4(pos, 1.0f);
	//gl_Position = lightSpaceMatrix * model * vec4(vs_out.FragPos, 1.0f);

	gl_Position = projection * view * model * vec4(pos, 1.0f);

}