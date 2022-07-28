import { CommandHandler, ICommandHandler } from '@nestjs/cqrs';
import { InjectModel } from '@nestjs/mongoose';
import { Model } from 'mongoose';
import { Gender } from '../../schemas';
import { GetGenderByName } from './get-gender-by-name';

@CommandHandler(GetGenderByName)
export class GetGenderByNameHandler
  implements ICommandHandler<GetGenderByName, Gender | null>
{
  constructor(
    @InjectModel(Gender.name) private readonly _genderModel: Model<Gender>,
  ) {}

  execute(command: GetGenderByName): Promise<Gender | null> {
    return this._genderModel.where({ name: command.name }).findOne().exec();
  }
}
