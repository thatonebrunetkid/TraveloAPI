using Application.Common;
using Application.Models;
using Application.UserTypes.Contracts;
using AutoMapper;
using Domain.Common.DTO;
using Domain.User.DTO;
using Domain.User.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserTypes.Handlers.Commands
{
    public class RefreshPasswordInitializeRequest : IRequest<HttpStatusCode>
    {
        public string Email { get; set; }
    }

    public class RefreshPasswordInitializeHandler : IRequestHandler<RefreshPasswordInitializeRequest, HttpStatusCode>
    {
        private readonly IUserRepository Repository;
        private readonly IEmailSender EmailSender;
        private readonly IRedisHandler RedisHandler;

        public RefreshPasswordInitializeHandler(IUserRepository Repository, IMapper Mapper, IEmailSender EmailSender, IRedisHandler RedisHandler)
        {
            this.Repository = Repository;
            this.EmailSender = EmailSender;
            this.RedisHandler = RedisHandler;
        }

        public async Task<HttpStatusCode> Handle(RefreshPasswordInitializeRequest request, CancellationToken cancellationToken)
        {
            if (Repository.CheckEmail(request.Email))
            {
                var ActivityId = RedisHandler.PrepareActivityKey();
                var email = new Email
                {
                    To = request.Email,
                    HtmlBody = $"<!DOCTYPE html>\n\n<html lang=\"en\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:v=\"urn:schemas-microsoft-com:vml\">\n<head>\n    <title></title>\n    <meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\"/>\n    <meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\"/>\n    <!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->\n    <style>\n        * {{\n            box-sizing: border-box;\n        }}\n\n        body {{\n            margin: 0;\n            padding: 0;\n        }}\n\n        a[x-apple-data-detectors] {{\n            color: inherit !important;\n            text-decoration: inherit !important;\n        }}\n\n        #MessageViewBody a {{\n            color: inherit;\n            text-decoration: none;\n        }}\n\n        p {{\n            line-height: inherit\n        }}\n\n        .desktop_hide,\n        .desktop_hide table {{\n            mso-hide: all;\n            display: none;\n            max-height: 0px;\n            overflow: hidden;\n        }}\n\n        @media (max-width:520px) {{\n            .desktop_hide table.icons-inner {{\n                display: inline-block !important;\n            }}\n\n            .icons-inner {{\n                text-align: center;\n            }}\n\n            .icons-inner td {{\n                margin: 0 auto;\n            }}\n\n            .image_block img.big,\n            .row-content {{\n                width: 100% !important;\n            }}\n\n            .mobile_hide {{\n                display: none;\n            }}\n\n            .stack .column {{\n                width: 100%;\n                display: block;\n            }}\n\n            .mobile_hide {{\n                min-height: 0;\n                max-height: 0;\n                max-width: 0;\n                overflow: hidden;\n                font-size: 0px;\n            }}\n\n            .desktop_hide,\n            .desktop_hide table {{\n                display: table !important;\n                max-height: none !important;\n            }}\n        }}\n    </style>\n</head>\n<body style=\"background-color: #FFFFFF; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;\">\n<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"nl-container\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #FFFFFF;\" width=\"100%\">\n    <tbody>\n    <tr>\n        <td>\n            <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #000000;\" width=\"100%\">\n                <tbody>\n                <tr>\n                    <td>\n                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 500px;\" width=\"500\">\n                            <tbody>\n                            <tr>\n                                <td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">\n                                    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"image_block block-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\" style=\"width:100%;padding-right:0px;padding-left:0px;\">\n                                                <div align=\"center\" class=\"alignment\" style=\"line-height:10px\"><img class=\"big\" src=\"https://i.ibb.co/DfQNHZz/logo.png\" style=\"display: block; height: auto; border: 0; width: 500px; max-width: 100%;\" width=\"500\"/></div>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                </td>\n                            </tr>\n                            </tbody>\n                        </table>\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n            <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-2\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                <tbody>\n                <tr>\n                    <td>\n                        <table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; border-radius: 0; width: 500px;\" width=\"500\">\n                            <tbody>\n                            <tr>\n                                <td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">\n                                    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"heading_block block-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\" style=\"width:100%;text-align:center;\">\n                                                <h1 style=\"margin: 0; color: #555555; font-size: 23px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; line-height: 120%; text-align: center; direction: ltr; font-weight: 700; letter-spacing: normal; margin-top: 0; margin-bottom: 0;\"><span class=\"tinyMce-placeholder\">Hi!</span></h1>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                    <table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"paragraph_block block-2\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\">\n                                                <div style=\"color:#000000;font-size:14px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;font-weight:400;line-height:120%;text-align:center;direction:ltr;letter-spacing:0px;mso-line-height-alt:16.8px;\">\n                                                    <p style=\"margin: 0; margin-bottom: 16px;\">we already recieved information about password change request, please click the link</p>\n                                                    <p style=\"margin: 0;\"> </p>\n                                                </div>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                    <table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"button_block block-3\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">\n                                        <tr>\n                                            <td class=\"pad\">\n                                                <div align=\"center\" class=\"alignment\">\n                                                    <!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" href=\"https://monumental-lily-16eef3.netlify.app/refresh-password/{ActivityId}\" style=\"height:35px;width:80px;v-text-anchor:middle;\" arcsize=\"12%\" stroke=\"false\" fillcolor=\"#00b9f2\"><w:anchorlock/><v:textbox inset=\"0px,0px,0px,0px\"><center style=\"color:#ffffff; font-family:Arial, sans-serif; font-size:14px\"><![endif]--><a href=\"https://monumental-lily-16eef3.netlify.app/refresh-password/{ActivityId}\" style=\"text-decoration:none;display:inline-block;color:#ffffff;background-color:#00b9f2;border-radius:4px;width:auto;border-top:0px solid transparent;font-weight:400;border-right:0px solid transparent;border-bottom:0px solid transparent;border-left:0px solid transparent;padding-top:5px;padding-bottom:5px;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;font-size:14px;text-align:center;mso-border-alt:none;word-break:keep-all;\" target=\"_blank\"><span style=\"padding-left:20px;padding-right:20px;font-size:14px;display:inline-block;letter-spacing:normal;\"><span style=\"line-height: 25.2px;\">Reset password</span></span></a>\n                                                    <!--[if mso]></center></v:textbox></v:roundrect><![endif]-->\n                                                </div>\n                                            </td>\n                                        </tr>\n                                    </table>\n                                </td>\n                            </tr>\n                            </tbody>\n                        </table>\n                    </td>\n                </tr>\n                </tbody>\n            </table>\n        </td>\n    </tr>\n    </tbody>\n</table><!-- End -->\n</body>\n</html>",
                    PlainText = "",
                    Subject = "Password Change"
                };

                if (RedisHandler.SetData(request.Email, ActivityId).Result)
                {
                    await EmailSender.SendEmail(email);
                    return HttpStatusCode.OK;
                }
                else
                    return HttpStatusCode.InternalServerError;
            }
            else
                return HttpStatusCode.BadRequest;
        }
    }
}
