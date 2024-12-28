using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthSystem.Migrations
{
    /// <inheritdoc />
    public partial class Recommendation_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "Id", "Description", "Study_Link" },
                values: new object[,]
                {
                    { 1, "Metabolic syndrome is a clustering of at least three of the following five medical conditions: abdominal obesity, high blood pressure, high blood sugar, high serum triglycerides, and low serum high-density lipoprotein (HDL). Metabolic syndrome is associated with the risk of developing cardiovascular disease and type 2 diabetes. In the U.S., about 25% of the adult population has metabolic syndrome, a proportion increasing with age, particularly among racial and ethnic minorities.", "https://en.wikipedia.org/wiki/Metabolic_syndrome" },
                    { 2, "Excess body weight and adiposity cause insulin resistance, inflammation, and numerous other alterations in metabolic and hormonal factors that promote atherosclerosis, tumorigenesis, neurodegeneration, and aging. Studies in both animals and humans have demonstrated a beneficial role of dietary restriction and leanness in promoting health and longevity.", "https://pmc.ncbi.nlm.nih.gov/articles/PMC4032609/" },
                    { 3, "There are two categories of normal blood pressure: Normal blood pressure is usually considered to be between 90/60 mmHg and 120/80 mmHg. For over-80s, because it's normal for arteries to get stiffer as we get older, the ideal blood pressure is under 150/90 mmHg (or 145/85 mmHg at home).", "https://academic.oup.com/eurheartj/article/45/38/3912/7741010?login=false" },
                    { 4, "Overweight and obesity may increase your risk for many health problems—especially if you carry extra fat around your waist. Reaching and staying at a healthy weight can help prevent these problems, stop them from getting worse, or even make them go away.", "https://www.niddk.nih.gov/health-information/weight-management/adult-overweight-obesity/health-risks?dkrd=/health-information/weight-management/health-risks-overweight" },
                    { 5, "Resting heart rate (RHR), a known cardiovascular risk factor, changes with age.", "https://openheart.bmj.com/content/6/1/e000856" },
                    { 6, "Regularly having high blood sugar levels for long periods of time (over months or years) can result in permanent damage to parts of the body such as the eyes, nerves, kidneys and blood vessels.", "https://www.nhsinform.scot/illnesses-and-conditions/blood-and-lymph/hyperglycaemia-high-blood-sugar/" },
                    { 7, "Hyperinsulinemia happens when you have a higher amount of insulin in your blood than what's considered normal due to insulin resistance. Your pancreas has to work harder to manage your blood sugar levels by releasing extra insulin.", "https://my.clevelandclinic.org/health/diseases/24178-hyperinsulinemia" },
                    { 8, "HDL is called \"good\" cholesterol because it helps prevent low-density lipoprotein (LDL) \"bad\" cholesterol and triglycerides from building up in the arteries. HDL picks up LDL in the blood and carries it to the liver. The liver breaks down LDL cholesterol, and it is passed from the body as waste.", "https://www.mountsinai.org/health-library/tests/hdl-test" },
                    { 9, "LDL is called \"bad\" cholesterol because it can build up and form fatty deposits (plaques) in the walls of your arteries.", "https://www.mountsinai.org/health-library/tests/ldl-test" },
                    { 10, "Having a high level of triglycerides in your blood can increase your risk of heart disease. But the same lifestyle choices that promote overall health can help lower your triglycerides, too.", "https://www.mayoclinic.org/diseases-conditions/high-blood-cholesterol/in-depth/triglycerides/art-20048186" }
                });

            migrationBuilder.InsertData(
                table: "TriggerParameters",
                columns: new[] { "Id", "DynamicsScore", "InformationTypeId", "RecommendationId" },
                values: new object[,]
                {
                    { 1, 0, 10, 1 },
                    { 2, -1, 10, 1 },
                    { 3, 1, 10, 1 },
                    { 4, 2, 10, 1 },
                    { 5, 0, 1, 2 },
                    { 6, -1, 1, 2 },
                    { 7, 1, 1, 2 },
                    { 8, 2, 1, 2 },
                    { 9, 0, 2, 3 },
                    { 10, -1, 2, 3 },
                    { 11, 1, 2, 3 },
                    { 12, 2, 2, 3 },
                    { 13, 0, 3, 4 },
                    { 14, -1, 3, 4 },
                    { 15, 1, 3, 4 },
                    { 16, 2, 3, 4 },
                    { 17, 0, 4, 5 },
                    { 18, -1, 4, 5 },
                    { 19, 1, 4, 5 },
                    { 20, 2, 4, 5 },
                    { 21, 0, 5, 6 },
                    { 22, -1, 5, 6 },
                    { 23, 1, 5, 6 },
                    { 24, 2, 5, 6 },
                    { 25, 0, 6, 7 },
                    { 26, -1, 6, 7 },
                    { 27, 1, 6, 7 },
                    { 28, 2, 6, 7 },
                    { 29, 0, 8, 8 },
                    { 30, -1, 8, 8 },
                    { 31, 1, 8, 8 },
                    { 32, 2, 8, 8 },
                    { 33, 0, 9, 9 },
                    { 34, -1, 9, 9 },
                    { 35, 1, 9, 9 },
                    { 36, 2, 9, 9 },
                    { 37, 0, 7, 10 },
                    { 38, -1, 7, 10 },
                    { 39, 1, 7, 10 },
                    { 40, 2, 7, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TriggerParameters",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
