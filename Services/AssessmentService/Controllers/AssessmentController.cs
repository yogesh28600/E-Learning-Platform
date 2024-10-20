using AssessmentService.DTO;
using AssessmentService.Models;
using AssessmentService.Repositories.QuestionsRepo;
using AssessmentService.Repositories.QuizRepo;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentService.Controllers
{
    [Route("assessment-service/[controller]/[action]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly IQuestionsRepo _questionsRepo;
        private readonly IQuizRepo _quizRepo;
        public AssessmentController(IQuizRepo quizRepo, IQuestionsRepo questionsRepo)
        {
            _questionsRepo = questionsRepo;
            _quizRepo = quizRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _questionsRepo.GetQuestions();
            return Ok(questions);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuestionById(Guid id)
        {
            var question = await _questionsRepo.GetQuestionById(id);
            if (question == null)
                return NotFound();
            return Ok(question);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(QuestionDTO model)
        {
            if (model.QuestionText == null || model.AnswerOptions == null || model.QuizId == Guid.Empty || model.CorrectAnswer == null)
                return BadRequest("Invalid Data");
            QuestionModel questionModel = new QuestionModel()
            {
                QuestionText = model.QuestionText,
                AnswerOptions = model.AnswerOptions,
                CorrectAnswer = model.CorrectAnswer,
                QuizId = model.QuizId,
                CreatedAt = DateTime.UtcNow,
            };
            var question = await _questionsRepo.CreateQuestion(questionModel);
            return CreatedAtAction(nameof(CreateQuestion), question);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateQuestion(QuestionDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest("Invalid Data");
            QuestionModel questionModel = await _questionsRepo.GetQuestionById(model.Id);
            if (questionModel == null)
                return NotFound();
            questionModel.QuestionText = model.QuestionText ?? questionModel.QuestionText;
            questionModel.AnswerOptions = model.AnswerOptions ?? questionModel.AnswerOptions;
            questionModel.CorrectAnswer = model.CorrectAnswer ?? questionModel.CorrectAnswer;
            questionModel.UpdatedAt = DateTime.UtcNow;
            var question = await _questionsRepo.UpdateQuestion(questionModel);
            return Ok(question);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var question = await _questionsRepo.DeleteQuestion(id);
            if (question == Guid.Empty)
                return BadRequest("Invalid Data");
            return Ok(question);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuiz()
        {
            var quiz = await _quizRepo.GetQuiz();
            return Ok(quiz);
        }
        [HttpGet]
        public async Task<IActionResult> GetQuizById(Guid id)
        {
            var quiz = await _quizRepo.GetQuizById(id);
            if (quiz == null)
                return NotFound();
            return Ok(quiz);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuiz(QuizDTO model)
        {
            if (model.Title == null || model.CourseId == Guid.Empty)
                return BadRequest("Invalid Data");
            QuizModel quizModel = new QuizModel()
            {
                Title = model.Title,
                CourseId = model.CourseId,
                CreatedAt = DateTime.UtcNow
            };
            var quiz = await _quizRepo.CreateQuiz(quizModel);
            return CreatedAtAction(nameof(CreateQuestion), quiz);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateQuiz(QuizDTO model)
        {
            if (model.Id == Guid.Empty)
                return BadRequest("Invalid Data");
            QuizModel quizModel = await _quizRepo.GetQuizById(model.Id);
            if (quizModel == null)
                return NotFound();
            quizModel.Title = model.Title ?? quizModel.Title;
            quizModel.UpdatedAt = DateTime.UtcNow;
            var quiz = await _quizRepo.UpdateQuiz(quizModel);
            return Ok(quiz);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var quiz = await _quizRepo.DeleteQuiz(id);
            if (quiz == Guid.Empty)
                return BadRequest("Invalid Data");
            return Ok(quiz);
        }
    }
}
