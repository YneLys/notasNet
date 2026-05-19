import { useState, useEffect } from 'react';
import "./App.css";

function App() {
  const [nome, setNome] = useState("");
  const [nota1, setNota1] = useState("");
  const [nota2, setNota2] = useState("");
  const [alunos, setAlunos] = useState([]);

  async function CarregarAlunos() {
    const resposta = await fetch("http://localhost:5080/api/alunos");
    const dados = await resposta.json();
    setAlunos(dados);  
  }

  async function CadastrarAlunos(e) {
    e.preventDefault();

    const aluno = {
      nome: nome,
      nota1: Number(nota1),
      nota2: Number(nota2),
    };

    await fetch("http://localhost:5080/api/alunos", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },   
      body: JSON.stringify(aluno),
    });

    setNome("");
    setNota1("");
    setNota2("");
    CarregarAlunos();
  }
  
  useEffect(() => {
    CarregarAlunos();

  }, []);

  return (
    <div> 
      <h1>Sistema de Notas</h1>

      <form onSubmit={CadastrarAlunos}>
        <input
          type="text"
          placeholder="Nome do aluno"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
        />
        <input
          type="number"
          placeholder="Nota 1"
          value={nota1}
          onChange={(e) => setNota1(e.target.value)}
        />
        <input
          type="number"
          placeholder="Nota 2"
          value={nota2}
          onChange={(e) => setNota2(e.target.value)}
        />
        <button type="submit">Cadastrar Alunos</button>

      </form>

      <h2>Alunos Cadastrados</h2>
      <ul>
        {alunos.map((aluno) => (
          <li key={aluno.id}>
            <strong>{aluno.nome}</strong> - Nota 1: {aluno.nota1}, Nota 2: {aluno.nota2}
          </li>
        ))}
      </ul>
    </div>
  );
} 

export default App;