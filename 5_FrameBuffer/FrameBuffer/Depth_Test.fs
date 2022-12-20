#version 330 core

in vec2 tex;
out vec4 fragColor;

uniform sampler2D DiffuseTexture;

float near = 0.1f;
float far = 100.0f;

float linear_depth(float depth)
{
	float z = 2.0 * depth - 1.0;
	return (2.0 * near * far) / (far + near - z * (far - near));
}

void main()
{
	//fragColor = texture(DiffuseTexture, tex);
	//fragColor = vec4(vec3(gl_FragCoord.z), 1.0f);

	float depth = linear_depth(gl_FragCoord.z) / far; // divide by far for demonstration
    fragColor = vec4(vec3(depth), 1.0);
}