using Application.Common;
using Application.Models;
using Application.UserTypes.Contracts;
using AutoMapper;
using Domain.Common.DTO;
using Domain.User;
using Domain.User.DTO;
using Domain.User.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserTypes.Handlers.Commands
{
    public class CreateUserCommandRequest : IRequest<BaseCommandResponse>
    {
        public CreateUserDTO CreateUserDTO { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseCommandResponse>
    {
        private readonly IUserRepository Repository;
        private readonly IMapper Mapper;
        private readonly IEmailSender EmailSender;

        public CreateUserCommandHandler(IUserRepository Repository, IMapper Mapper, IEmailSender EmailSender)
        {
            this.Repository = Repository;
            this.Mapper = Mapper;
            this.EmailSender = EmailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDtoValidator();
            var validatorResult = await validator.ValidateAsync(request.CreateUserDTO);

            if(!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validatorResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var user = Mapper.Map<User>(new User()
            {
                Name = request.CreateUserDTO.Name,
                Surname = request.CreateUserDTO.Surname,
                PhoneNumber = request.CreateUserDTO.PhoneNumber,
                Email = request.CreateUserDTO.Email,
                Password = request.CreateUserDTO.Password,
                PasswordDateUpdated = DateTime.Now,
                DateCreated = DateTime.Now
            });

            user = await Repository.AddNewUser(user);

            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = user.UserId;

            var email = new Email
            {
                To = request.CreateUserDTO.Email,
                HtmlBody = $"<!DOCTYPE html>\n\n<html lang=\"en\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:v=\"urn:schemas-microsoft-com:vml\">\n<head>\n    <title></title>\n    <meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\"/>\n    <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\"/>\n    <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->\n    <style>\n        * {{\n            box-sizing: border-box;\n        }}\n\n        body {{\n            margin: 0;\n            padding: 0;\n        }}\n\n        a[x-apple-data-detectors] {{\n            color: inherit !important;\n            text-decoration: inherit !important;\n        }}\n\n        #MessageViewBody a {{\n            color: inherit;\n            text-decoration: none;\n        }}\n\n        p {{\n            line-height: inherit\n        }}\n\n        .desktop_hide,\n        .desktop_hide table {{\n            mso-hide: all;\n            display: none;\n            max-height: 0px;\n            overflow: hidden;\n        }}\n\n        @media (max-width:520px) {{\n            .desktop_hide table.icons-inner {{\n                display: inline-block !important;\n            }}\n\n            .icons-inner {{\n                text-align: center;\n            }}\n\n            .icons-inner td {{\n                margin: 0 auto;\n            }}\n\n            .image_block img.big,\n            .row-content {{\n                width: 100% !important;\n            }}\n\n            .mobile_hide {{\n                display: none;\n            }}\n\n            .stack .column {{\n                width: 100%;\n                display: block;\n            }}\n\n            .mobile_hide {{\n                min-height: 0;\n                max-height: 0;\n                max-width: 0;\n                overflow: hidden;\n                font-size: 0px;\n            }}\n\n            .desktop_hide,\n            .desktop_hide table {{\n                display: table !important;\n                max-height: none !important;\n            }}\n        }}\n    </style>\n</head>\n<body style=\"background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;\">\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"nl-container\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;\" width=\"100%\">\n    <tbody>\n    <tr>\n        <td>\n            <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #000000;\" width=\"100%\">\n                <tbody>\n                <tr>\n                    <td>\n                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;\" width=\"500\">\n                            <tbody>\n                            <tr>\n                                <td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">\n                                    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"image_block block-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\" style=\"width:100%;padding-right:0px;padding-left:0px;\">\n                                                <div align=\"center\" class=\"alignment\" style=\"line-height:10px\"><img class=\"big\" src=\"https://i.ibb.co/DfQNHZz/logo.png\" style=\"display: block; height: auto; border: 0; width: 500px; max-width: 100%;\" width=\"500\"/></div>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                </td>\n                            </tr>\n                            </tbody>\n                        </table>\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n            <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-2\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                <tbody>\n                <tr>\n                    <td>\n                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; border-radius: 0; width: 500px;\" width=\"500\">\n                            <tbody>\n                            <tr>\n                                <td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">\n                                    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"heading_block block-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\" style=\"width:100%;text-align:center;\">\n                                                <h1 style=\"margin: 0; color: #555555; font-size: 23px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;\"><span class=\"tinyMce-placeholder\">Hi {request.CreateUserDTO.Name}!</span></h1>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                    <table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"paragraph_block block-2\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\">\n                                                <div style=\"color:#000000;font-size:14px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;font-weight:400;line-height:120%;text-align:center;direction:ltr;letter-spacing:0px;mso-line-height-alt:16.8px;\">\n                                                    <p style=\"margin: 0;\">We are very grateful to have joined us. If you have any question please contact us on travelodeveloper@gmail.com</p>\n                                                </div>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                </td>\n                            </tr>\n                            </tbody>\n                        </table>\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n        </td>\n    </tr>\n    </tbody>\n</table><!-- End -->\n</body>\n</html>",
                Subject = "Welcome to Travelo Family",
                PlainText = ""
            };

            try
            {
                await EmailSender.SendEmail(email);
            }catch(Exception)
            {
                //
            }

            return response;
        }
    }
}
