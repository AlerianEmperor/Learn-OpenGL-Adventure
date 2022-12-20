#version 430 core

layout (triangles) in;
layout (line_strip, max_vertices = 2) out;

in VS_OUT
{
	vec3 normal;
} gs_in[];


const float strength = 0.2f;

void CreateVertex(int index)
{

	gl_Position = gl_in[index].gl_Position;
	EmitVertex();

	gl_Position = (gl_in[index].gl_Position + vec4(gs_in[index].normal, 0.0f) * strength);
	EmitVertex();

	EndPrimitive();
}

void main()
{
	/*gl_Position = projection * gl_in[0].gl_Position;
	EmitVertex();

	gl_Position = projection * (gl_in[0].gl_Position + vec4(gs_in[0].normal, 0.0f) * strength);
	EmitVertex();

	EndPrimitive();*/

	CreateVertex(0);
	CreateVertex(1);
	CreateVertex(2);

}

