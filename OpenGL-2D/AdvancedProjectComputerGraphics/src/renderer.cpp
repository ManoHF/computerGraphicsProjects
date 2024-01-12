#include "Renderer.h"
#include <iostream>

void GLClearError() {
	while( glGetError() != GL_NO_ERROR );
}

bool GLLogCall( const char* function, const char* file, int line ) {
	while( GLenum error = glGetError() ) {
		std::cout << "[OpenGl Error] ( " << error << " )" << function << " " << file << ": " << line << std::endl;
		return false;
	}
	return true;
}

void Renderer::clear() const {
    glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
}

void Renderer::drawIndex( const VertexArray& va, const IndexBuffer& ib, const Shader& shader ) const {
	shader.bind();
	va.bind();
	ib.bind();
	GLCall( glDrawElements( GL_TRIANGLES, ib.getCount(), GL_UNSIGNED_INT, nullptr ) );
}

void Renderer::draw(const VertexArray& va, const Shader& shader, int size, int offset) const {
    shader.bind();
    va.bind();
    GLCall(glDrawArrays(GL_TRIANGLES, offset, size));
}

/*
 * Funcion: drawEllipse()
 * --------------------
 * Create the vertices of an ellipse centered on (x, y) with radious of a and b and stores its values in 'vertices'.
 * It generates vertices from the angle 'min' to 'max' and with the colors (R, G, B).
 *
 * Parameters: float x, y - center of figure
 *             float a, b - semi-major and semi-minor axis
 *             float depth - depth in the drawing window
 *             float R, G, B - figure's colors
 *             float min, max - angle limits to draw parts of the figure
 *             std::vector<glm::vec3> vertices - memory space to store vertices
 *
 */
void Renderer::drawEllipse(float x, float y, float a, float b, float depth, std::vector<float>& vertices, float R, float G, float B, float min, float max) {
    std::vector<glm::vec3> temp;

    for (int i = 0; i < 2001; i++) {
        float angle1 = min + (max - min) * i / 2000;
        float angle2 = min + (max - min) * (i + 1) / 2000;

        float x1 = x + a * cos(angle1);
        float y1 = y + b * sin(angle1);
        float x2 = x + a * cos(angle2);
        float y2 = y + b * sin(angle2);

        vertices.push_back(x);
        vertices.push_back(y);
        vertices.push_back(depth);
        vertices.push_back(1.0f);
        vertices.push_back(R);
        vertices.push_back(G);
        vertices.push_back(B);
        vertices.push_back(1.0f);

        vertices.push_back(x1);
        vertices.push_back(y1);
        vertices.push_back(depth);
        vertices.push_back(1.0f);
        vertices.push_back(R);
        vertices.push_back(G);
        vertices.push_back(B);
        vertices.push_back(1.0f);

        vertices.push_back(x2);
        vertices.push_back(y2);
        vertices.push_back(depth);
        vertices.push_back(1.0f);
        vertices.push_back(R);
        vertices.push_back(G);
        vertices.push_back(B);
        vertices.push_back(1.0f);
    }
}

/*
 * Funcion: insertRectangle()
 * --------------------
 * Creates the vertices of a rectangle centered on (x, y) with certain 'height' and 'width' and stores its values in 'vertices'.
 * It creates the vertices with (R, G, B) colors and a certain 'depth'
 *
 * Parameters: float x, y - center of figure
 *             float height, width - height and width of the rectangle
 *             float depth - depth in the drawing window
 *             float R, G, B - figure's colors
 *             std::vector<glm::vec3> vertices - memory space to store vertices
 *
 */
void Renderer::insertRectangle(float x, float y, float height, float width, std::vector<float>& vertices, float R, float G, float B, float depth)
{
    std::vector<float> rect = {
        x, y, depth, 1.0f,          R, G, B, 1.0f,
        x, y - height, depth, 1.0f,   R, G, B, 1.0f,
        x + width, y, depth, 1.0f,    R, G, B, 1.0f,

        x + width, y, depth, 1.0f,        R, G, B, 1.0f,
        x + width, y - height, depth, 1.0f, R, G, B, 1.0f,
        x, y - height, depth, 1.0f,       R, G, B, 1.0f
    };

    vertices.insert(vertices.end(), rect.begin(), rect.end());

}
