using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace ESTRUYALGOFORMSporKEY
{
    public partial class Form1 : Form
    {
        private List<int> data = new List<int>();
        private Stack<int> pila = new Stack<int>();
        private Queue<int> cola = new Queue<int>();
        private List<int> lista = new List<int>();
        private BinaryTree arbol = new BinaryTree();
        private Graph grafo = new Graph();
        public Form1()
        {
            InitializeComponent();
        }
     
      

        // Métodos de ordenamiento y partición aquí

        private void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            data.Clear();
            MessageBox.Show("Datos limpiados.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agrega los algoritmos de ordenamiento al ComboBox
            cmbOrdenamientos.Items.Add("Bubble Sort");
            cmbOrdenamientos.Items.Add("Selection Sort");
            cmbOrdenamientos.Items.Add("Insertion Sort");
            cmbOrdenamientos.Items.Add("QuickSort");
            cmbOrdenamientos.Items.Add("MergeSort");
            cmbOrdenamientos.Items.Add("HeapSort");
            cmbOrdenamientos.Items.Add("ShellSort");
            cmbOrdenamientos.Items.Add("CountingSort");
            cmbOrdenamientos.Items.Add("RadixSort");
            cmbOrdenamientos.Items.Add("Salir");

            // Selecciona el primer elemento por defecto
            cmbOrdenamientos.SelectedIndex = 0;
        }
    
        static void BubbleSort(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = 0; j < data.Count - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        // Intercambiar elementos si están en el orden incorrecto
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Datos ordenados con Bubble Sort.");
        }

        static void SelectionSort(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                int minIndex = i;

                // Encontrar el índice del elemento mínimo en el resto del array
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (data[j] < data[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Intercambiar el elemento mínimo con el primer elemento sin ordenar
                int temp = data[minIndex];
                data[minIndex] = data[i];
                data[i] = temp;
            }

            Console.WriteLine("Datos ordenados con Selection Sort.");
        }

        static void InsertionSort(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                int key = data[i];
                int j = i - 1;

                // Mover los elementos del array que son mayores que key a una posición adelante de su posición actual
                while (j >= 0 && data[j] > key)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                // Insertar el elemento key en su posición correcta
                data[j + 1] = key;
            }

            Console.WriteLine("Datos ordenados con Insertion Sort.");
        }
        static void QuickSort(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(data, low, high);

                QuickSort(data, low, partitionIndex - 1);
                QuickSort(data, partitionIndex + 1, high);
            }

        }
        static int Partition(List<int> data, int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    Swap(data, i, j);
                }
            }

            Swap(data, i + 1, high);
            return i + 1;
        }

        static void Swap(List<int> data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        static void MergeSort(List<int> data, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(data, left, middle);
                MergeSort(data, middle + 1, right);

                Merge(data, left, middle, right);
            }
        }

        static void Merge(List<int> data, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(data.ToArray(), left, leftArray, 0, n1);
            Array.Copy(data.ToArray(), middle + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    data[k] = leftArray[i];
                    i++;
                }
                else
                {
                    data[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                data[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                data[k] = rightArray[j];
                j++;
                k++;
            }
        }

        static void HeapSort(List<int> data)
        {
            int n = data.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(data, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = data[0];
                data[0] = data[i];
                data[i] = temp;

                Heapify(data, i, 0);
            }
        }

        static void Heapify(List<int> data, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && data[left] > data[largest])
                largest = left;

            if (right < n && data[right] > data[largest])
                largest = right;

            if (largest != i)
            {
                int swap = data[i];
                data[i] = data[largest];
                data[largest] = swap;

                Heapify(data, n, largest);
            }
        }

        static void ShellSort(List<int> data)
        {
            int n = data.Count;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = data[i];
                    int j;
                    for (j = i; j >= gap && data[j - gap] > temp; j -= gap)
                        data[j] = data[j - gap];

                    data[j] = temp;
                }
            }
        }

       
        static void CountingSort(List<int> data)
        {
            int n = data.Count;
            int[] output = new int[n];

            int max = data.Max();
            int min = data.Min();
            int range = max - min + 1;

            int[] count = new int[range];
            int[] outputData = new int[n];

            for (int i = 0; i < n; i++)
                count[data[i] - min]++;

            for (int i = 1; i < range; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[data[i] - min] - 1] = data[i];
                count[data[i] - min]--;
            }

            for (int i = 0; i < n; i++)
                data[i] = output[i];
        }
        static void RadixSort(List<int> data)
        {
            int max = data.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
                CountingSortRadix(data, exp);
        }

        static void CountingSortRadix(List<int> data, int exp)
        {
            int n = data.Count;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
                count[(data[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(data[i] / exp) % 10] - 1] = data[i];
                count[(data[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
                data[i] = output[i];
        }





        // Dentro de la clase Form1, después de los métodos de ordenamiento

        // Método para agregar un elemento a la pila
        private void PushToStack(int element)
        {
            pila.Push(element);
            MessageBox.Show($"Elemento {element} agregado a la pila.");
        }

        // Método para eliminar un elemento de la pila
        private void PopFromStack()
        {
            if (pila.Count > 0)
            {
                int poppedElement = pila.Pop();
                MessageBox.Show($"Elemento {poppedElement} eliminado de la pila.");
            }
            else
            {
                MessageBox.Show("La pila está vacía.");
            }
        }

        // Método para encolar un elemento
        private void EnqueueToQueue(int element)
        {
            cola.Enqueue(element);
            MessageBox.Show($"Elemento {element} encolado.");
        }

        // Método para desencolar un elemento
        private void DequeueFromQueue()
        {
            if (cola.Count > 0)
            {
                int dequeuedElement = cola.Dequeue();
                MessageBox.Show($"Elemento {dequeuedElement} desencolado.");
            }
            else
            {
                MessageBox.Show("La cola está vacía.");
            }
        }

        // Método para agregar un elemento a la lista
        private void AddToList(int element)
        {
            lista.Add(element);
            MessageBox.Show($"Elemento {element} agregado a la lista.");
        }

        // Método para eliminar un elemento de la lista
        private void RemoveFromList(int element)
        {
            if (lista.Contains(element))
            {
                lista.Remove(element);
                MessageBox.Show($"Elemento {element} eliminado de la lista.");
            }
            else
            {
                MessageBox.Show($"El elemento {element} no está en la lista.");
            }
        }

        // Método para insertar un elemento en el árbol
        // Método para insertar un elemento en el árbol con prioridad
        private void InsertIntoTree(int element, string priority)
        {
            arbol.Insertar(element, priority);
            MessageBox.Show($"Elemento {element} con prioridad {priority} insertado en el árbol.");
        }

        // Método para buscar un elemento en el árbol
        private void SearchInTree(int element)
        {
            if (arbol.Search(element))
            {
                MessageBox.Show($"El elemento {element} está en el árbol.");
            }
            else
            {
                MessageBox.Show($"El elemento {element} no está en el árbol.");
            }
        }


        // Método para agregar un vértice al grafo
        private void AddVertexToGraph(int vertex)
        {
            grafo.AddVertex(vertex);
            MessageBox.Show($"Vértice {vertex} agregado al grafo.");
        }

        // Método para agregar una arista al grafo
        private void AddEdgeToGraph(int startVertex, int endVertex)
        {
            grafo.AddEdge(startVertex, endVertex);
            MessageBox.Show($"Arista agregada entre {startVertex} y {endVertex} en el grafo.");
        }

        // Método para mostrar el grafo
        private void DisplayGraph()
        {
            MessageBox.Show("Representación del grafo:\n" + grafo.ToString());
        }

        private void btnEjecutarOrdenamientos_Click_1(object sender, EventArgs e)
        {
            // Obtener el tipo de ordenamiento seleccionado
            int selectedSort = cmbOrdenamientos.SelectedIndex;

            // Ejecutar el algoritmo de ordenamiento correspondiente
            switch (selectedSort)
            {
                case 0:
                    BubbleSort(data);
                    break;
                case 1:
                    SelectionSort(data);
                    break;
                case 2:
                    InsertionSort(data);
                    break;
                case 3:
                    QuickSort(data, 0, data.Count - 1);
                    break;
                case 4:
                    MergeSort(data, 0, data.Count - 1);
                    break;
                case 5:
                    HeapSort(data);
                    break;
                case 6:
                    ShellSort(data);
                    break;
                case 7:
                    CountingSort(data);
                    break;
                case 8:
                    RadixSort(data);
                    break;
                    // Añade más casos según sea necesario para otros algoritmos
            }

            // Mostrar los datos ordenados
            MessageBox.Show("Datos ordenados: " + string.Join(", ", data));
        
    }

        private void btnAgregarDatos_Click_1(object sender, EventArgs e)
        {
            // Puedes validar la entrada del usuario aquí
            string input = txtDatos.Text;
            string[] elementos = input.Split(' ');

            foreach (var elemento in elementos)
            {
                if (int.TryParse(elemento, out int num))
                {
                    data.Add(num);
                }
            }
            cmbOrdenamientos.Refresh();

            MessageBox.Show("Datos agregados correctamente.");
        }

        private void btnLIMPIAR_Click(object sender, EventArgs e)
        {
            data.Clear();
            txtDatos.Clear();
            pila.Clear();
            cola.Clear();
            lista.Clear();
            //arbol.Clear();
            grafo.Clear();

            MessageBox.Show("Datos limpiados.");
        }

        private void btnAgregarPila_Click(object sender, EventArgs e)
        {
            // Agregar un elemento a la pila
            if (int.TryParse(txtElementoPila.Text, out int elemento))
            {
                pila.Push(elemento);
                UpdatePilaListBox();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
            }
        }

        private void btnEliminarPila_Click(object sender, EventArgs e)
        {
            // Eliminar un elemento de la pila
            if (pila.Count > 0)
            {
                pila.Pop();
                UpdatePilaListBox();
            }
            else
            {
                MessageBox.Show("La pila está vacía.");
            }
        }

       

        private void UpdatePilaListBox()
        {
            // Actualizar la ListBox con los elementos de la pila
            listBox1.Items.Clear();
            foreach (var elemento in pila)
            {
                listBox1.Items.Add(elemento);
            }
        }

        private void btnAgregarCola_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtElementoCola.Text, out int elemento))
            {
                cola.Enqueue(elemento);
                UpdateColaListBox();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
            }
        }

        private void btnEliminarCola_Click(object sender, EventArgs e)
        {
            if (cola.Count > 0)
            {
                cola.Dequeue();
                UpdateColaListBox();
            }
            else
            {
                MessageBox.Show("La cola está vacía.");
            }

        }
        private void UpdateColaListBox()
        {
            listBoxCola.Items.Clear();
            foreach (var elemento in cola)
            {
                listBoxCola.Items.Add(elemento);
            }
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtElementoLista.Text, out int elemento))
            {
                lista.Add(elemento);
                UpdateListaListBox();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido.");
            }
        }

        private void btnEliminarLista_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                lista.RemoveAt(lista.Count - 1);
                UpdateListaListBox();
            }
            else
            {
                MessageBox.Show("La lista está vacía.");
            }
        }
        private void UpdateListaListBox()
        {
            listBoxLista.Items.Clear();
            foreach (var elemento in lista)
            {
                listBoxLista.Items.Add(elemento);
            }
        }

        private void btnAgregarArbol_Click(object sender, EventArgs e)
        {
            string[] entrada = txtArbol.Text.Split(' ');

            if (entrada.Length == 2 && int.TryParse(entrada[0], out int num))
            {
                string prioridad = entrada[1].ToLower(); // Tomar la segunda parte como prioridad en minúsculas
                if (EsPrioridadValida(prioridad))
                {
                    arbol.Insertar(num, prioridad);
                    UpdateArbolListBox();
                }
                else
                {
                    MessageBox.Show("Prioridad no válida. Se asignará 'media' por defecto.");
                    arbol.Insertar(num, "media");
                    UpdateArbolListBox();
                }
            }
            else
            {
                MessageBox.Show("Formato de entrada incorrecto. Por favor, ingrese un número y su prioridad (por ejemplo, '3 alta').");
            }
        }

        private void btnEliminarArbol_Click(object sender, EventArgs e)
        {
            if (listBoxArbol.SelectedIndex != -1)
            {
                // Se ha seleccionado un elemento en la ListBox
                string selectedItem = listBoxArbol.SelectedItem.ToString();
                string[] parts = selectedItem.Split(' ');

                if (parts.Length == 2 && int.TryParse(parts[0], out int num))
                {
                    string priority = parts[1].Trim('(', ')').ToLower();

                    arbol.Eliminar(num, priority);
                    UpdateArbolListBox();
                }
                else
                {
                    MessageBox.Show("No se pudo determinar el valor y la prioridad del elemento seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar.");
            }

        }
        private void UpdateArbolListBox()
        {
            listBoxArbol.Items.Clear();
            arbol.RecorridoInorden(listBoxArbol);
        }
        private bool EsPrioridadValida(string prioridad)
        {
            return prioridad == "alta" || prioridad == "media" || prioridad == "baja";
        }
        private void TraverseAndAddToList(NodoArbol nodo, ListBox.ObjectCollection items)
        {
            if (nodo != null)
            {
                TraverseAndAddToList(nodo.Izquierdo, items);
                string nodeInfo = $"{nodo.Valor} ({nodo.Prioridad})";
                items.Add(nodeInfo);
                TraverseAndAddToList(nodo.Derecho, items);
            }
        }



        private void btnAgregarVerticeGrafo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtVerticeGrafo.Text, out int vertice))
            {
                grafo.AddVertex(vertice);
                UpdateGrafoListBox();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido para el vértice.");
            }
        }

        private void btnEliminarVerticeGrafo_Click(object sender, EventArgs e)
        {
            if (listBoxGrafos.SelectedIndex != -1)
            {
                int vertice = (int)listBoxGrafos.SelectedItem;
                grafo.RemoveVertex(vertice);
                UpdateGrafoListBox();
            }
            else
            {
                MessageBox.Show("Seleccione un vértice para eliminar.");
            }
        }

        private void btnAgregarAristaGrafo_Click(object sender, EventArgs e)
        {
            // Verificar si los datos ingresados son números válidos
            if (int.TryParse(txtInicioArista.Text, out int inicio) && int.TryParse(txtFinArista.Text, out int fin))
            {
                // Verificar si los vértices existen en el grafo
                if (grafo.ContainsVertex(inicio) && grafo.ContainsVertex(fin))
                {
                    // Agregar la arista
                    grafo.AddEdge(inicio, fin);
                    UpdateGrafoListBox();
                }
                else
                {
                    MessageBox.Show("Ingrese vértices válidos existentes en el grafo.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese números válidos para los vértices de la arista.");
            }
        }

        private void btnEliminarAristaGrafo_Click(object sender, EventArgs e)
        {
            if (listBoxAristas.SelectedIndex != -1)
            {
                string arista = listBoxAristas.SelectedItem.ToString();
                string[] vertices = arista.Split('-');
                int inicio = int.Parse(vertices[0]);
                int fin = int.Parse(vertices[1]);
                grafo.RemoveEdge(inicio, fin);
                UpdateGrafoListBox();
            }
            else
            {
                MessageBox.Show("Seleccione una arista para eliminar.");
            }
        }
        private void UpdateGrafoListBox()
        {
            listBoxGrafos.Items.Clear();
            foreach (var vertex in grafo.GetVertices())
            {
                listBoxGrafos.Items.Add(vertex);
            }

            listBoxAristas.Items.Clear();
            foreach (var edge in grafo.GetEdges())
            {
                listBoxAristas.Items.Add(edge);
            }
        }

        private void listBoxPila_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public class NodoArbol
    {
        public int Valor;
        public string Prioridad;
        public NodoArbol Izquierdo;
        public NodoArbol Derecho;
    }

    public class BinaryTree
    {

        private NodoArbol raiz;

        public void Insertar(int valor, string prioridad)
        {
            raiz = InsertarRec(raiz, valor, prioridad);
        }

        private NodoArbol InsertarRec(NodoArbol nodo, int valor, string prioridad)
        {
            if (nodo == null)
            {
                nodo = new NodoArbol();
                nodo.Valor = valor;
                nodo.Prioridad = prioridad;
                nodo.Izquierdo = nodo.Derecho = null;
            }
            else if (prioridad.CompareTo(nodo.Prioridad) < 0 || (prioridad == nodo.Prioridad && valor < nodo.Valor))
            {
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor, prioridad);
            }
            else
            {
                nodo.Derecho = InsertarRec(nodo.Derecho, valor, prioridad);
            }
            return nodo;
        }

        public void Eliminar(int valor, string prioridad)
        {
            raiz = EliminarRec(raiz, valor, prioridad);
        }

        private NodoArbol EliminarRec(NodoArbol nodo, int valor, string prioridad)
        {
            if (nodo == null)
            {
                return nodo;
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor, prioridad);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRec(nodo.Derecho, valor, prioridad);
            }
            else
            {
                // Nodo encontrado, realizar la eliminación
                if (nodo.Izquierdo == null)
                {
                    return nodo.Derecho;
                }
                else if (nodo.Derecho == null)
                {
                    return nodo.Izquierdo;
                }

                // Nodo con dos hijos: encontrar el sucesor inorden (el más grande en el subárbol izquierdo)
                nodo.Valor = EncontrarMaximo(nodo.Izquierdo);

                // Eliminar el sucesor inorden
                nodo.Izquierdo = EliminarRec(nodo.Izquierdo, nodo.Valor, prioridad);
            }

            return nodo;
        }

        private int EncontrarMaximo(NodoArbol nodo)
        {
            int maxValue = nodo.Valor;
            while (nodo.Derecho != null)
            {
                maxValue = nodo.Derecho.Valor;
                nodo = nodo.Derecho;
            }
            return maxValue;
        }


        public void RecorridoInorden(ListBox listBox)
        {
            RecorridoInordenRec(raiz, listBox);
        }

        private void RecorridoInordenRec(NodoArbol nodo, ListBox listBox)
        {
            if (nodo != null)
            {
                RecorridoInordenRec(nodo.Izquierdo, listBox);
                string nodeInfo = $"{nodo.Valor} ({nodo.Prioridad})";
                listBox.Items.Add(nodeInfo);
                RecorridoInordenRec(nodo.Derecho, listBox);
            }
        }
          public bool Search(int valor)
    {
        return SearchRec(raiz, valor);
    }

    private bool SearchRec(NodoArbol nodo, int valor)
    {
        if (nodo == null)
        {
            return false;
        }

        if (valor == nodo.Valor)
        {
            return true;
        }

        if (valor < nodo.Valor)
        {
            return SearchRec(nodo.Izquierdo, valor);
        }
        else
        {
            return SearchRec(nodo.Derecho, valor);
        }
    }

    }


        public class Graph
    {
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddVertex(int vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<int>();
            }
        }
        public bool ContainsVertex(int vertex)
        {
            return adjacencyList.ContainsKey(vertex);
        }

        public void RemoveVertex(int vertex)
        {
            adjacencyList.Remove(vertex);

            // Eliminar el vértice de las listas de adyacencia de otros vértices
            foreach (var adjList in adjacencyList.Values)
            {
                adjList.Remove(vertex);
            }
        }

        public void AddEdge(int startVertex, int endVertex)
        {
            if (adjacencyList.ContainsKey(startVertex) && adjacencyList.ContainsKey(endVertex))
            {
                adjacencyList[startVertex].Add(endVertex);
                adjacencyList[endVertex].Add(startVertex); // Assuming an undirected graph
            }
        }

        public void RemoveEdge(int startVertex, int endVertex)
        {
            if (adjacencyList.ContainsKey(startVertex) && adjacencyList.ContainsKey(endVertex))
            {
                adjacencyList[startVertex].Remove(endVertex);
                adjacencyList[endVertex].Remove(startVertex);
            }
        }

        public List<int> GetVertices()
        {
            return new List<int>(adjacencyList.Keys);
        }

        public List<string> GetEdges()
        {
            HashSet<string> edgesSet = new HashSet<string>();

            foreach (var vertex in adjacencyList.Keys)
            {
                foreach (var neighbor in adjacencyList[vertex])
                {
                    // Ordenar los vértices para asegurar una representación única
                    string edge = $"{Math.Min(vertex, neighbor)}-{Math.Max(vertex, neighbor)}";
                    edgesSet.Add(edge);
                }
            }

            return edgesSet.ToList();
        }


        public void Clear()
        {
            adjacencyList.Clear();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var vertex in adjacencyList.Keys)
            {
                result.Append($"{vertex}: ");
                result.Append(string.Join(", ", adjacencyList[vertex]));
                result.AppendLine();
            }
            return result.ToString();
        }
    }

}