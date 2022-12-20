#version 430 core
out vec4 FragColor;

in vec2 TexCoords;

uniform sampler2D screenTexture;

void main()
{
	//mat hang nay trong rat la chi con quad
    //vec3 col = texture(screenTexture, TexCoords).rgb;
    
	FragColor = texture(screenTexture, TexCoords);

	//float average = (FragColor.x + FragColor.y + FragColor.z) / 3.0f;
	//FragColor = vec4(vec3(1.0f) - col, 1.0);
	
	//float average = 0.2126f * FragColor.r + 0.7152f * FragColor.g + 0.0722f * FragColor.b;

	//FragColor = vec4(average, average, average, 1.0f);
}

/*
const float offset = 1.0 / 300.0;  

void main()
{
	vec2 offsets[9] = vec2[](
        vec2(-offset,  offset), // top-left
        vec2( 0.0f,    offset), // top-center
        vec2( offset,  offset), // top-right
        vec2(-offset,  0.0f),   // center-left
        vec2( 0.0f,    0.0f),   // center-center
        vec2( offset,  0.0f),   // center-right
        vec2(-offset, -offset), // bottom-left
        vec2( 0.0f,   -offset), // bottom-center
        vec2( offset, -offset)  // bottom-right    
    );

    float kernel[9] = float[](
        -1, -1, -1,
        -1,  9, -1,
        -1, -1, -1
    );

	vec3 sampleTex[9];

	for(int i = 0; i < 9; ++i)
		sampleTex[i] = texture(screenTexture, TexCoords.st + offsets[i]).rgb;

	vec3 col = vec3(0.0f);

	for(int i = 0; i < 9; ++i)
		col += kernel[i] * sampleTex[i];

	FragColor = vec4(col, 1.0f);
}
*/