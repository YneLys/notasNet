using Microsoft.AspNetCore.Mvc;
using SistemaNotas.Api.Models;

namespace SistemaNotas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private static List<Aluno> alunos = new();
    private static int proximoId = 1;

    [HttpGet]
    public ActionResult<List<Aluno>> Listar()
    {
        return Ok(alunos);
    }

    [HttpPost]
    public ActionResult<Aluno> Cadastrar(Aluno aluno)
    {
        aluno.Id = proximoId++;
        aluno.Media = (aluno.Nota1 + aluno.Nota2) / 2;
        aluno.Situacao = aluno.Media >= 7 ? "Aprovado" : "Reprovado";

        alunos.Add(aluno);

        return Ok(aluno);
    }
}