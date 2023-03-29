
using LMS.Repositories;
using LMS.Service;
using LMS.Context;
using Microsoft.EntityFrameworkCore;
using LMS.DTO.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LMS")));
//builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient<ITaiKhoanService, TaiKhoanService>();
builder.Services.AddTransient<ITaiKhoanRepository, AccountRepositories>();
builder.Services.AddTransient<ITeacherRepositories, TeacherRepositories>();
builder.Services.AddTransient<ITeacherService, TeacherService>();

builder.Services.AddTransient<IClassRoomRepositories, ClassRoomRepositories>();
builder.Services.AddTransient<IDetailsLessonRepositories, DetailsLessonRepositories>();
builder.Services.AddTransient<IDetailsSubjectRepositories, DetailsSubjectRepositories>();
builder.Services.AddTransient<ILessonRepositories, LessonRepositories>();
builder.Services.AddTransient<ISubjectRepositories, SubjectRepositories>();
builder.Services.AddTransient<ITeachingSubjectRepositories, TeachingSubjectRepositories>();
builder.Services.AddTransient<ITopicSubjectRepositories, TopicSubjectRepositories>();

builder.Services.AddTransient<IClassRoomService, ClassRoomService>();
builder.Services.AddTransient<IDetailsLessonService, DetailsLessonService>();
builder.Services.AddTransient<IDetailsSubjectService, DetailsSubjectService>();
builder.Services.AddTransient<ILessonService, LessonService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<ITeachingSubjectService, TeachingSubjectService>();
builder.Services.AddTransient<ITopicSubjectService, TopicSubjectService>();
builder.Services.AddTransient<IStudentSubjectRepositories, StudentSubjectRepositories>();
builder.Services.AddTransient<IStudentSubjectService, StudentSubjectService>();

builder.Services.AddTransient<IFileService, DowloadLesson>();
builder.Services.AddTransient<IExamRepositories, ExamRepositories>();
builder.Services.AddTransient<IExamService, ExamService>();
builder.Services.AddTransient<IDetailExamRepositories, DetailExamRepositories>();
builder.Services.AddTransient<IDetailExamService, DetailExamService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
